import { Customer } from "./customers"

export type User = {
  id: string,
  username: string,
  customer: Customer,
}