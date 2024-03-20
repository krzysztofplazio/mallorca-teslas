import { Dayjs } from "dayjs"

export type Customer = {
  id?: number,
  fullName: string,
  dateOfBirth: Dayjs,
  address: string,
  country: string,
  phone: string,
  email: string,
}