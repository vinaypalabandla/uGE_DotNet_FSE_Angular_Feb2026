import { ChangeDetectorRef, Component, OnInit } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { ProductService } from '../../services/product-service';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-product-component',
  standalone: true,
  imports: [CommonModule,FormsModule],
  providers: [ProductService],
  templateUrl: './product-component.html',
  styleUrl: './product-component.css'
})
export class ProductComponent implements OnInit {

  products: any[] = [];

  constructor(
    public productService: ProductService,
    public changeDetectorRef: ChangeDetectorRef
  ) {}

  ngOnInit(): void {
    this.loadProducts();
  }

  loadProducts() {
    this.productService.getProducts().subscribe(data => {
      this.products = data;
      this.changeDetectorRef.detectChanges();
    });
  }
}