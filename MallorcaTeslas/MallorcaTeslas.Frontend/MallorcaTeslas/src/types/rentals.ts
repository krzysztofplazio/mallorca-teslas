import { Dayjs } from "dayjs"
import { Customer } from "./customers"

export type CreateRentalRequest = {
  totalPrice: number,
  from: Dayjs,
  to: Dayjs,
  borrowPlaceId: number,
  returnPlaceId: number,
  customer?: Customer,
  carId: number,
  customerId?: number;
}

export type RentalRow = {
  id: number,
  totalPrice: number,
  from: Dayjs,
  to: Dayjs,
  borrowPlace: string,
  returnPlace: string,
  car: string,
}