import { Component, OnInit } from '@angular/core';
import { FormBuilder, AbstractControl, Validators } from '@angular/forms';
import { CryptoService } from '../crypto.service';

interface CryptoCurrency {
  viewValue: string;
  value: string;
}

@Component({
  selector: 'app-exchange',
  templateUrl: './exchange.component.html',
  styleUrls: ['./exchange.component.css']
})
export class ExchangeComponent implements OnInit {

  currencies: CryptoCurrency[] = [
    {'viewValue': 'Bitcoin', 'value': 'btc'},
    {'viewValue': 'Ethereum', 'value' : 'eth'},
    {'viewValue': 'Cardano', 'value' : 'ada'},
    {'viewValue': 'BNB', 'value' : 'bnb'},
    {'viewValue': 'Tether', 'value' : 'usdt'}
  ];
  exchanges : any;
  isVisible: boolean = false;
  loading: boolean = false;
  submitted: boolean = false;
  apiError: boolean = false;
  form = this.formBuilder.group({
    Currency: ['', Validators.required],
    Amount: ['', [Validators.required, Validators.min(1)]],
    CurrenciesToExchange: ''
  });

  constructor(
    private cryptoService: CryptoService,
    private formBuilder: FormBuilder
  ) { }

  ngOnInit(): void {
  }

  get f(): { [key: string]: AbstractControl } {
    return this.form.controls;
  }

  getExchanges(body: {}) {
    this.loading = true;
    this.isVisible = false;
    this.cryptoService.getExchanges(body).subscribe(
      (response) => { this.exchanges = response; this.isVisible = true; this.loading = false},
      (error) => { this.loading = false; this.apiError = true; console.log(error); });
  }

  onSubmit() {
    this.submitted = true;
    if (!this.form.valid) return;

    this.form.value.CurrenciesToExchange = this.currencies
                                        .map(x => x.value)
                                        .filter(x => x != this.form.value.Currency)
    this.getExchanges(this.form.value)
  }
}
