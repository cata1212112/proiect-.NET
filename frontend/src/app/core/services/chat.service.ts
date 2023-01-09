import { Injectable } from '@angular/core';
import * as signalR from '@microsoft/signalr';
import {MessageDTO} from "../../DTOs/MessageDTO";
import {Observable, Subject} from "rxjs";
import {HttpClient} from "@microsoft/signalr";

@Injectable({
  providedIn: 'root'
})
export class ChatService {
  private connection: any = new signalR.HubConnectionBuilder().withUrl("https://localhost:7243/api/Chat").configureLogging(signalR.LogLevel.Information).build();

  readonly POST_URL = "https://localhost:7243/api/Chat/send"

  private receivedMessageObject: MessageDTO = new MessageDTO();
  private sharedObj = new Subject<MessageDTO>();


  constructor(private http: HttpClient) {
    this.connection.onclose(async () => {
      await this.start();
    });
    this.connection.on("ReceiveOne", (user:any, message:any) => { this.mapReceivedMessage(user, message); });
    this.start();
  }

  public async start() {
    try {
      await this.connection.start();
      console.log("connected");
    } catch (err) {
      console.log(err);
      setTimeout(() => this.start(), 5000);
    }
  }

  private mapReceivedMessage(user: string, message: string): void {
    this.receivedMessageObject.user = user;
    this.receivedMessageObject.msgText = message;
    this.sharedObj.next(this.receivedMessageObject);
  }

  public broadcastMessage(msgDto: any) {
    this.http.post(this.POST_URL, msgDto).then(data => console.log(data));
  }

  public retrieveMappedObject(): Observable<MessageDTO> {
    return this.sharedObj.asObservable();
  }
}
