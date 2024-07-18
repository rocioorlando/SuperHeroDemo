import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { AppComponent } from './app.component';
import { HttpClientModule } from '@angular/common/http';
import { SuperHeroComponent } from './components/superhero/superhero.component';
import { FormsModule } from '@angular/forms';
import { AdivinanzaComponent } from './components/adivinanza/adivinanza.component';

@NgModule({
  declarations: [
    AppComponent,
    SuperHeroComponent,
    AdivinanzaComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    FormsModule 
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
