import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { SuperHero } from '../models/superhero.model';

@Injectable({
  providedIn: 'root'
})
export class SuperHeroService {

  private apiURL = 'https://localhost:7276/api/SuperHero';

  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json'
    })
  };

  constructor(private httpClient: HttpClient) { }

  getAllSuperHeroes(): Observable<SuperHero[]> {
    return this.httpClient.get<SuperHero[]>(this.apiURL)
      .pipe(
        catchError(this.errorHandler)
      );
  }

  getSuperHeroById(id: number): Observable<SuperHero> {
    return this.httpClient.get<SuperHero>(`${this.apiURL}/${id}`)
      .pipe(
        catchError(this.errorHandler)
      );
  }

  addSuperHero(superHero: SuperHero): Observable<SuperHero> {
    return this.httpClient.post<SuperHero>(this.apiURL, JSON.stringify(superHero), this.httpOptions)
      .pipe(
        catchError(this.errorHandler)
      );
  }

  updateSuperHero(id: number, superHero: SuperHero): Observable<void> {
    return this.httpClient.put<void>(`${this.apiURL}/${id}`, superHero, this.httpOptions)
      .pipe(
        catchError(this.errorHandler)
      );
}

  deleteSuperHero(id: number): Observable<void> {
    return this.httpClient.delete<void>(`${this.apiURL}/${id}`, this.httpOptions)
      .pipe(
        catchError(this.errorHandler)
      );
  }

  errorHandler(error: any) {
    let errorMessage = '';
    if (error.error instanceof ErrorEvent) {
      errorMessage = error.error.message;
    } else {
      errorMessage = `Error Code: ${error.status}\nMessage: ${error.message}`;
    }
    return throwError(errorMessage);
  }
}
