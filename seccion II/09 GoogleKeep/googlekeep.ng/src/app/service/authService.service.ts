import { Injectable } from "@angular/core";
import { BasicService } from "./basic.service";
import { SessionService } from "./session.service";
import { jwtDecode } from "jwt-decode";
import { catchError, map, Observable, throwError } from "rxjs";
import { Router } from "@angular/router";

@Injectable({providedIn: 'root'})
export class AuthService {
    constructor(private session: SessionService, private http: BasicService, private route: Router) {}

    login(email: string, password: string): Observable<any> {
        return this.http.basePost(`authentication/loginv2`, { "email": email, "password": password });
    }

    verifycode(email: string, code: string): Observable<any> {
        return this.http.basePostText(`authentication/verifycode/${email}/${code}`, null).pipe(
            map((token: string | null) => {
                const normalizedToken = token?.trim();

                if (!normalizedToken) {
                    throw new Error('Verification succeeded but no JWT was returned by the server.');
                }

                console.log('TOKEN::', normalizedToken);
                this.session.save(normalizedToken);
                return normalizedToken;
            }),
            catchError((error: any) => {
                console.error('Verification error:', error);
                return throwError(() => error instanceof Error ? error : new Error(error?.error?.message ?? 'Verification failed'));
            })
        );
    }

    logout(): void {
        this.session.delete();
        this.route.navigate(['/auth/login']);
    }

    getToken(): string | null {
        return this.session.get();
    }

    isAuthenticated(): boolean {
        var jwt = this.session.get();
        if(!jwt) return false;
        try {
            var payload: any = jwtDecode(jwt);
            const now = Math.floor(Date.now() / 1000);
            if (!payload?.exp || payload.exp <= now) {
                this.session.delete();
                return false;
            }

            return true;
        } catch (e) {
            this.session.delete();
            return false;
        }
    }
}