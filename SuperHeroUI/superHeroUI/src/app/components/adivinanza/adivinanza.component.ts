import { Component, OnInit } from '@angular/core';
import { AdivinanzaService } from 'src/app/services/AdivinanzaService';

@Component({
  selector: 'app-adivinanza',
  templateUrl: './adivinanza.component.html',
  styleUrls: ['./adivinanza.component.css']
})
export class AdivinanzaComponent implements OnInit {

  constructor(private adivinanzaService: AdivinanzaService) { }

  ngOnInit() {
    this.reiniciarJuego();
    this.enviarNumeroUsuario(5);
  }

  reiniciarJuego(){
    this.adivinanzaService.reiniciarJuego().subscribe(
      (mensaje) => {
        console.log("Mensaje", mensaje);
      },
      (error) => {
        console.error('Error adding hero', error);
      }
    );
  }

  enviarNumeroUsuario(numero: number){
    this.adivinanzaService.enviarNumeroUsuario(numero).subscribe(
      (mensaje) => {
        console.log("Mensaje", mensaje);
      },
      (error) => {
        console.error('Error adding hero', error);
      }
    );
  }

}
