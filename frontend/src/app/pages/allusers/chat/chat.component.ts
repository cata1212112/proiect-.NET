import {Component, Input, OnInit} from '@angular/core';
import {ChatService} from "../../../core/services/chat.service";
import {MessageDTO} from "../../../DTOs/MessageDTO";
import {AuthService} from "../../../core/services/auth.service";
import {ActivatedRoute} from "@angular/router";

@Component({
  selector: 'app-chat',
  templateUrl: './chat.component.html',
  styleUrls: ['./chat.component.scss']
})
export class ChatComponent implements OnInit{
  public user1:string = "";
  public user2:any = "";

  public msgDto: MessageDTO = new MessageDTO();
  public msgInboxArray: MessageDTO[] = [];

  constructor(private chatService: ChatService, private authservice:AuthService, private route: ActivatedRoute) {}

  ngOnInit(): void {
    this.user2 = this.route.snapshot.paramMap.get('username');
    this.user1 = this.authservice.getLoggedUser().username;
    this.chatService.retrieveMappedObject().subscribe( (receivedObj: MessageDTO) => { this.addToInbox(receivedObj);});
  }

  send(): void {
    this.msgDto.user = this.user1;
    if(this.msgDto) {
      if(this.msgDto.user.length == 0 || this.msgDto.user.length == 0){
        window.alert("Both fields are required.");
        return;
      } else {
        this.chatService.broadcastMessage(this.msgDto);                   // Send the message via a service
      }
    }
  }

  addToInbox(obj: MessageDTO) {
    let newObj = new MessageDTO();
    newObj.user = obj.user;
    newObj.msgText = obj.msgText;
    this.msgInboxArray.push(newObj);

  }

}
