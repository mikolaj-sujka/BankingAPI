import { Component, OnInit, ViewEncapsulation } from '@angular/core';
import { AbstractControl, FormBuilder, FormGroup, ValidatorFn, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { AccountService } from '../_services/account.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css'],
})
export class RegisterComponent implements OnInit {
  registerForm: FormGroup;

  constructor(private accountService: AccountService, private router: Router, 
    private formBuilder: FormBuilder, private toastr: ToastrService) { }

  ngOnInit(): void {
    this.initializeForm();
  }

  initializeForm(){
    this.registerForm = this.formBuilder.group({  
      username: ['', [Validators.required,
        Validators.minLength(6), Validators.maxLength(20)]], 
      firstName: ['', [Validators.required, Validators.pattern('^[a-zA-Z \-\']+')]], 
      lastName: ['', [Validators.required, Validators.pattern('^[a-zA-Z \-\']+')]], 
      email: ['', Validators.required], 
      city: ['', [Validators.required, Validators.pattern('^[a-zA-Z \-\']+')]], 
      country: ['', [Validators.required, Validators.pattern('^[a-zA-Z \-\']+')]], 
      postalCode: ['', [Validators.required, Validators.pattern('^\\d{2}(-\\d{3})?$')]], 
      dateOfBirth: ['', Validators.required],
      password: ['', [Validators.required,
        Validators.minLength(8), Validators.maxLength(12)]],
      confirmPassword: ['', [Validators.required, this.matchValues('password')]]
    })

    this.registerForm.controls.password.valueChanges.subscribe(() => {
      this.registerForm.controls.confirmPassword.updateValueAndValidity();
    })
  }

  matchValues(matchTo: string) : ValidatorFn {
    return (control: AbstractControl) => {
      return control?.value === control?.parent?.controls[matchTo].value 
        ? null : {isMatching: true}
    }
  }

  register() {
    this.accountService.register(this.registerForm.value).subscribe(response => {
      this.router.navigateByUrl('/account-page');
    }, error =>{
      this.toastr.error("Some values are provided wrongly!")
    })
  }


}
