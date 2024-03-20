import dayjs from "dayjs";
import { useEffect, useState } from "react";
import { getCarsByDates } from "../api/axios";

export function useCars() {
  const from = dayjs(sessionStorage.getItem('from'), { utc: true });
  const to = dayjs(sessionStorage.getItem('to'), { utc: true });
  const [cars, setCars] = useState<PagedItems<Car>>();

  useEffect(() => {
    const fetchCars = async () => {
      const result = await getCarsByDates(from!, to!);
      setCars(result);
    };
    fetchCars();
  }, [])

  return { from, to, cars };
}