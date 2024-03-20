import axios from "axios";
import config from "./axios.config";
import { Dayjs } from "dayjs";
import { CreateRentalRequest, RentalRow } from "../types/rentals";
import { User } from "../types/user";

const api = axios.create(config);

export const getCarsByDates = async (from: Dayjs, to: Dayjs) => {
  const result = await api.get<PagedItems<Car>>(`/api/cars?from=${from.toISOString()}&to=${to.toISOString()}`);
  return result.data;
}

export const getCarById = async (id: string) => {
  const result = await api.get<Car>(`/api/cars/${id}`);
  return result.data;
}

export const getPlaces = async () => {
  const result = await api.get<Place[]>(`/api/places`);
  return result.data;
}

export const createRental = async (request: CreateRentalRequest) => {
  await api.post("/api/rentals", JSON.stringify(request));
}

export const getRentals = async () => {
  const result = await api.get<PagedItems<RentalRow>>("/api/rentals?pageSize=-1");
  return result.data.items;
}

export const loginUser = async (credentials: LoginCredentials) => {
  await api.post("/api/auth/login", JSON.stringify(credentials));
}

export const getCurrentUser = async () => {
  const response = await api.get<User>("/api/users/me")
  return response.data;
}