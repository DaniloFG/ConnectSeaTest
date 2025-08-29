import { Component } from '@angular/core';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { HttpClient } from '@angular/common/http';
import Swal from 'sweetalert2';
import { Router } from '@angular/router';
import { Urls } from '../../Service/Urls';

@Component({
  selector: 'app-login.component',
  imports: [ReactiveFormsModule],
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent {
  loginForm!: FormGroup;

  constructor(private formBuilder: FormBuilder, private http: HttpClient, private router: Router) {
    this.loginForm = this.formBuilder.group({
      email: ['', [Validators.required, Validators.email]],
      password: ['', [Validators.required, Validators.min(8)]]
    });
  }

  onSubmit(): void {
    if (this.loginForm.valid) {
      this.router.navigate(['/app']);
      Swal.fire({
        icon: 'success',
        title: 'Login bem-sucedido!',
        text: 'Você será redirecionado em breve.',
        showConfirmButton: false,
        timer: 2000
      });

      // const payload = this.loginForm.value;
      //   this.http.post(Urls.urlLogin, payload)
      //     .subscribe({
      //       next: (response: any) => {
      //         Swal.fire({
      //           icon: 'success',
      //           title: 'Login bem-sucedido!',
      //           text: 'Você será redirecionado em breve.',
      //           showConfirmButton: false,
      //           timer: 2000
      //         });
      //         localStorage.setItem('accessToken', response.accessToken);
      //         this.router.navigate(['/app']);
      //       },
      //       error: (err) => {
      //         Swal.fire({
      //           icon: 'error',
      //           title: 'Opa...',
      //           text: 'Verifique os dados e tente novamente.',
      //           confirmButtonText: 'Ok'
      //         });
      //       }
      //     });
    }
  }
}
