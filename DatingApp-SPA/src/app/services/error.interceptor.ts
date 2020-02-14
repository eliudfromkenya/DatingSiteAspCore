import { Injectable } from "@angular/core";
import {
  HttpInterceptor,
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpErrorResponse,
  HTTP_INTERCEPTORS
  // tslint:disable-next-line: quotemark
} from "@angular/common/http";
// tslint:disable-next-line: quotemark
import { Observable, throwError } from "rxjs";
import { catchError } from "rxjs/operators";
@Injectable()
export class ErrorInterceptor implements HttpInterceptor {
  intercept(
    req: HttpRequest<any>,
    next: HttpHandler
  ): Observable<HttpEvent<any>> {
    return next.handle(req).pipe(
      catchError(error => {
        if (error instanceof HttpErrorResponse) {
          if (error.status === 402) {
            return throwError(
              "Access denied, because you are not authorized. Contact System Administrator"
            );
          }
          const applicationError = error.headers.get("Application-Error");
          if (applicationError) {
            return throwError(applicationError);
          }

          const serverError = error.error;
          let modalStateErrors = "";
          if (serverError && typeof serverError === "object") {
            for (const key in serverError) {
              if (serverError[key]) {
                modalStateErrors += serverError[key] + "\n";
              }
            }
          }
          return throwError(modalStateErrors || serverError || "Server Error");
        }
      })
    );
  }
}
export const ErrorInterceptorProvider = {
  provide: HTTP_INTERCEPTORS,
  useClass: ErrorInterceptor,
  multi: true
};