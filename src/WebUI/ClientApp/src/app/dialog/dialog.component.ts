import { Component, OnInit } from '@angular/core';
import { FormGroup ,FormBuilder,Validator, Validators} from '@angular/forms';
import { ApiService } from '../services/api.service';
import { MatDialogRef } from '@angular/material/dialog';
import { Inject} from '@angular/core';
import {MAT_DIALOG_DATA} from '@angular/material/dialog';
@Component({
  selector: 'app-dialog',
  templateUrl: './dialog.component.html',
  styleUrls: ['./dialog.component.scss']
})
export class DialogComponent implements OnInit {
  actionBtn:string= "Save";
  blogForm !:FormGroup;
  constructor(private formBuilder:FormBuilder,private api:ApiService , private dilogRef:MatDialogRef<DialogComponent>,
    @Inject(MAT_DIALOG_DATA) public editData: any
    ) { }

  ngOnInit(): void {
    this.blogForm= this.formBuilder.group({
      title : ["",Validators.required],
      body : ["",Validators.required],
      creationDate : ["",Validators.required],
    });
    if(this.editData){
      this.actionBtn = "Update";
      // this.blogForm.controls['id'].setValue(this.editData.Id);
      this.blogForm.controls['title'].setValue(this.editData.title);
      this.blogForm.controls['body'].setValue(this.editData.body);
      this.blogForm.controls['creationDate'].setValue(this.editData.creationDate);
      
   
   }
  }

  addBlog(): void{
if(!this.editData){
  if(this.blogForm.valid){
    this.api.postBlog(this.blogForm.value)
    .subscribe({
      next:(res)=>{
        alert("blog added Successfully");
        this.blogForm.reset();
        this.dilogRef.close();
      },
      error:()=>{
        alert("Error While Saving")
      }
    })
  }
}
else{
  this.updateBlog()
}
  }
  updateBlog(){
    this.api.putBlog(this.blogForm.value,this.editData.id)
    .subscribe({
      next:(res)=>{
        alert("blo updated successfully");
        this.blogForm.reset();
        this.dilogRef.close('update');
      },
      error:()=>{
        alert("error while updating")
      }
    })
  }

}
