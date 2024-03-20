type Car = {
  id: number,
  mark: string,
  model: string,
  chargingMinutes: number,
  power: number,
  productionYear: number,
  pricePerDay: number,
  pricePerMonth: number,
  currency: string,
  rangeLimit: number,
  rentDays: number,
}

type PagedItems<T> = {
  page: number,
  pageSize: number,
  totalCount: number
  totalPages: number,
  items: T[],
}