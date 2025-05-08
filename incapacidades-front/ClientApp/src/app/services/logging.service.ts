import { Injectable } from '@angular/core';
import { Router } from '@angular/router';

@Injectable({
    providedIn: 'root'
})
export class LoggingService {

    constructor(
        private router: Router
    ) {
      
    }

    logError(message: string, stack: string) {
        // Send errors to server here
        
        console.log('LoggingService: ' + message);
        //this.router.navigate(['/account/login']);
        
    }
}
