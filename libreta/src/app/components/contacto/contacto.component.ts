import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { ContactoService } from 'src/app/services/contacto.service';

@Component({
  selector: 'app-contacto',
  templateUrl: './contacto.component.html',
  styleUrls: ['./contacto.component.css']
})
export class ContactoComponent implements OnInit {
  listcontactos: any = [];
  accion = 'Agregar';
  form: FormGroup;
  id: number | undefined;

  constructor(private fb: FormBuilder, private toastr: ToastrService, private _contactoService: ContactoService) {
    this.form = this.fb.group({
      nombre: ['', Validators.required],
      numerocelular: ['',[Validators.required, Validators.maxLength(9), Validators.minLength(9)]]
    })
   }

  ngOnInit(): void {
    this.obtenerContactos();
  }

  obtenerContactos(){
    this._contactoService.getListContactos().subscribe(data =>{
      console.log(data);
      this.listcontactos = data;
    }, error => {
      console.log(error);
    })
  }

  agregarNumero(){
    const contacto: any ={
      nombre: this.form.get('nombre')?.value,
      numero: this.form.get('numerocelular')?.value,
    }

    if(this.id == undefined){
      this._contactoService.savecontacto(contacto).subscribe(data =>{
        this.toastr.success('El contacto ha sido registrado con éxito', 'Contacto registrado');
        this.obtenerContactos();
        this.form.reset();
      }, error => {
        this.toastr.error('Ocurrió un error','Error');
        console.log(error);
      })
    }else{
      contacto.id = this.id;
      this._contactoService.updatecontacto(this.id, contacto).subscribe(data =>{
        this.form.reset();
        this.accion = 'Agregar';
        this.id = undefined;
        this.toastr.info('Contacto Editado', 'Contacto Actualizado')
        this.obtenerContactos();
      }, error =>{
        console.log(error);
      })
    }


    
    
  }

  eliminarContacto(id: number){
    this._contactoService.deletecontacto(id).subscribe(data =>{
      this.toastr.error('El contacto ha sido eliminado', 'Contacto eliminado')
      this.obtenerContactos();
    }, error =>{
      console.log(error);
    })
  }

  editarcontacto(contacto: any){
    this.accion = 'Editar';
    this.id = contacto.id;
    this.form.patchValue({
      nombre: contacto.nombre,
      numerocelular: contacto.numero,
    })
  }

}
