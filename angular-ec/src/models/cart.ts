export class Cart {
  cartDetailId: string;
  productId: string;
  productName: string;
  price: number;
  quantity: number;
  image: string;

  constructor(
    cartDetailId: string,
    productId: string,
    productName: string,
    price: number,
    quantity: number,
    image: string
  ) {
    this.cartDetailId = cartDetailId;
    this.productId = productId;
    this.productName = productName;
    this.price = price;
    this.quantity = quantity;
    this.image = image;
  }
}

export class CartRespone {
  totalItems: number;
  totalPrice: number;
  items: Cart[];
}

export class CartCreateRequest {
  productId: string;
  quantity: number;
}

export class CartUpdateRequest {
  cartDetailId: string;
  quantity: number;
}
