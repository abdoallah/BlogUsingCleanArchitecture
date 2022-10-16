
import { Component ,OnInit,ViewChild } from '@angular/core';
import { ApiService } from '../services/api.service';
import {MatPaginator} from '@angular/material/paginator';
import {MatSort} from '@angular/material/sort';
import {MatTableDataSource} from '@angular/material/table';
import {MatDialog, MAT_DIALOG_DATA} from '@angular/material/dialog';
import { DialogComponent } from '../dialog/dialog.component';
@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent {
  displayedColumns: string[] = ['title','body' ,'creationDate','actions'];
  dataSource: MatTableDataSource<any>;

  @ViewChild(MatPaginator) paginator!: MatPaginator;
  @ViewChild(MatSort) sort!: MatSort;
  constructor(private api : ApiService,private dialog:MatDialog){

  }
  ngOnInit():void{
    this.getAllBlogs();
  }
  getAllBlogs(){

    this.api.getBlog()
    .subscribe({
      next:(res)=>{
        console.log(res);
       this.dataSource = new MatTableDataSource(res);
       this.dataSource.paginator = this.paginator;
       this.dataSource.sort = this.sort;
      },
      error:(res)=>{
 
        alert("error while getting the data");
      }
    })
  }

  editBlog(row:any){
    this.dialog.open(DialogComponent,{
      width:'30%',
      data:row

    });

  }
  deleteBlog(id:number){
this.api.deleteBlog(id).subscribe({
  next:(res)=>{
    alert("deleted successfully");
  },
  error:()=>{
    alert("error while deleting");
  }
})
  }
  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();

    if (this.dataSource.paginator) {
      this.dataSource.paginator.firstPage();
    }
  }

}
