import {EventEmitter, Injectable, Output} from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {ApiService} from "./api.service";

@Injectable({
  providedIn: 'root'
})
export class FileuploadService {

  private readonly route = 'FileUpload';
  @Output() public onUploadFinished = new EventEmitter();

  constructor(private readonly apiService: ApiService) { }

  uploadFile(file:File) {
    const formData = new FormData();
    formData.append('file', file);
    console.log(formData);
    return this.apiService.post_formData(this.route + '/uploadfile', formData);
  }
}
