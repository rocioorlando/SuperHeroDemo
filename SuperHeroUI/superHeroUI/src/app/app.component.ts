import { Component, OnInit } from '@angular/core';
import { SuperHeroService } from './services/superhero.service';
import { SuperHero } from './models/superhero.model';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  superHeroes: SuperHero[] = [];
  errorMessage: string = '';

  constructor(private superHeroService: SuperHeroService) {}

  ngOnInit() {
    this.getAllSuperHeroes();
  }

  getAllSuperHeroes() {
    this.superHeroService.getAllSuperHeroes().subscribe(
      (data: SuperHero[]) => {
        this.superHeroes = data;
      },
      (error) => {
        this.errorMessage = error;
      }
    );
  }

  // Implementa otros métodos de la misma forma para agregar, actualizar y eliminar superhéroes
}
