import { Product } from './product';

export interface ProductPayload {
    products: Product[];
    count: number;
}
