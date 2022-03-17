import { Component, OnInit } from '@angular/core';
import { CryptoService } from '../crypto.service';

@Component({
  selector: 'app-quote',
  templateUrl: './quote.component.html',
  styleUrls: ['./quote.component.css']
})
export class QuoteComponent implements OnInit {

  quotes: any;
  apiError: boolean = false;
  loading: boolean = false;
  isVisible: boolean = false;
  constructor(
    private cryptoService: CryptoService,
  ) { }

  getQuotes(): void {
    this.loading = true;
    this.isVisible = false;
    this.cryptoService.getQuotes().subscribe(
      (response) => { this.quotes = response; this.isVisible = true; this.loading = false;},
      (error) => { this.loading = false; this.apiError = true; console.log(error); });
  }

  ngOnInit(): void {
    this.getQuotes();
    setInterval(()=> { 
      this.getQuotes();
    }, 5000);
  }
}
