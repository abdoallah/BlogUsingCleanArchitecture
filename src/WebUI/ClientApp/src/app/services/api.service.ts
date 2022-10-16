import { HttpClient,HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Blog } from '../blog';
@Injectable({
  providedIn: 'root'
})
export class ApiService {

  constructor(private http : HttpClient) { }
  htttOptions ={
    Headers:new HttpHeaders({
      'Content-type':'application/json'

    })
  }

  postBlog(data :any){
    return this.http.post<any>("https://localhost:44447/api/Blog/",data);
  }
  getBlog(){
    return this.http.get<any>("https://localhost:44447/api/Blog");
  }
  //  getBlogs():Observable<any>{
  // return this.http.get<any>("https://localhost:44447/api/Blog/",{headers:this.htttOptions.Headers});
  // }

 putBlog(data:any,id:number){
return this.http.put<any>("https://localhost:44447/api/Blog/"+id,data);
 }
 deleteBlog(id:number){
  return this.http.delete<any>("https://localhost:44447/api/Blog/"+id);
 }
}
