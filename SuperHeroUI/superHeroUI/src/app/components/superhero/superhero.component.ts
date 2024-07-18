import { Component, OnInit } from "@angular/core";
import { SuperHero } from "src/app/models/superhero.model";
import { SuperHeroService } from "src/app/services/superhero.service";

@Component({
  selector: 'app-super-hero',
  templateUrl: './superhero.component.html',
  styleUrls: ['./superhero.component.css']
})
export class SuperHeroComponent implements OnInit {
  superHeroes: SuperHero[] = [];
  searchTerm: string = '';
  newHero: SuperHero | null = null;


  constructor(private superHeroService: SuperHeroService) { }

  ngOnInit(): void {
    this.getAllSuperHeroes();
  }

  getAllSuperHeroes(): void {
    this.superHeroService.getAllSuperHeroes().subscribe(
      (heroes) => {
        this.superHeroes = heroes;
      },
      (error) => {
        console.error('Error fetching heroes', error);
      }
    );
  }

  searchHero(): void {
    if (this.searchTerm) {
      this.superHeroes = this.superHeroes.filter(hero =>
        hero.name.toLowerCase().includes(this.searchTerm.toLowerCase())
      );
    } else {
      this.getAllSuperHeroes(); 
    }
  }

  addHero(): void {
    this.newHero = {
      id: 0, 
      name: '', 
      superPowers: '',
      team: '',
      level: 1,
      isEditing: true
    };
    this.superHeroes.push(this.newHero);
  }

  saveHero(hero: SuperHero): void {
    if (this.validatingHero(hero)) {
      this.saveNewHero(hero);
    } else {
      this.updateSuperHero(hero);
    }
  }

  validatingHero(hero: SuperHero): boolean {
    return hero.id == 0
  }

  saveNewHero(hero: SuperHero): void {
    this.superHeroService.addSuperHero(hero).subscribe(
      (savedHero) => {
        Object.assign(hero, savedHero);
        hero.isEditing = false;
        this.newHero = null;
        console.log('Add Hero', hero);
      },
      (error) => {
        console.error('Error adding hero', error);
      }
    );
  }

  updateSuperHero(hero: SuperHero): void {
    this.superHeroService.updateSuperHero(hero.id, hero).subscribe(
      () => {
        hero.isEditing = false;
        console.log('Update Hero', hero);
      },
      (error) => {
        console.error('Error updating hero', error);
      }
    );
  }

  editHero(hero: SuperHero): void {
    hero.isEditing = true;
  }

  deleteHero(hero: SuperHero): void {
    this.superHeroService.deleteSuperHero(hero.id).subscribe(
      () => {
        this.superHeroes = this.superHeroes.filter(h => h.id !== hero.id);
        console.log('Delete Hero', hero);
      },
      (error) => {
        console.error('Error deleting hero', error);
      }
    );
  }


  
}
