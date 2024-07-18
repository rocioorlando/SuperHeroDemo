import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})

export class AdivinanzaService {

    private apiURL = 'https://localhost:7276/api/Adivinanza';
  
    httpOptions = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json'
      })
    };
  
    constructor(private httpClient: HttpClient) { }

    reiniciarJuego(): Observable<string> {
        return this.httpClient.post<string>(`${this.apiURL}/PostReiniciar`, this.httpOptions)
          .pipe(
            catchError(this.errorHandler)
        );
    }

    enviarNumeroUsuario(numero: number): Observable<string> {
        return this.httpClient.post<string>(this.apiURL, numero, this.httpOptions)
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