import dayjs, { Dayjs } from "dayjs";
import { useEffect, useState } from "react";
import { useNavigate, useParams } from "react-router-dom";
import { createRental, getCarById, getCurrentUser, getPlaces } from "../api/axios";
import { Customer } from "../types/customers";
import { SelectChangeEvent } from "@mui/material";
import { CreateRentalRequest } from "../types/rentals";
import { AxiosError } from "axios";
import { User } from "../types/user";

export default function useRentCar() {
  const navigate = useNavigate();
  const [from, setFrom] = useState<Dayjs | null>(dayjs(sessionStorage.getItem('from'), { utc: true }).startOf('day'));
  const [to, setTo] = useState<Dayjs | null>(dayjs(sessionStorage.getItem('to'), { utc: true }).startOf('day'));
  const { carId } = useParams();
  const [car, setCar] = useState<Car>();
  const [costs, setCosts] = useState<string>("");
  const [days, setDays] = useState<number>(0);
  const [selectedBorrowPlace, setSelectedBorrowPlace] = useState<string>("");
  const [selectedReturnPlace, setSelectedReturnPlace] = useState<string>("");
  const [borrowPlaces, setBorrowPlaces] = useState<Place[]>([]);
  const [returnPlaces, setReturnPlaces] = useState<Place[]>([]);
  const [error, setError] = useState("");
  const [user, setUser] = useState<User>();
  const [exceptionThrowned, setExceptionThrowned] = useState(false);
  const [customerData, setCustomerData] = useState<Customer>({
    fullName: "",
    dateOfBirth: dayjs().subtract(18, 'year'),
    address: "",
    country: "",
    phone: "",
    email: "",
  });
  const [request, setRequest] = useState<CreateRentalRequest>({
    totalPrice: 0,
    from: dayjs(),
    to: dayjs(),
    borrowPlaceId: 0,
    returnPlaceId: 0,
    customer: customerData,
    carId: Number(carId),
  });
  
  useEffect(() => {
    const fetchCar = async () => {
      const car = await getCarById(carId!);
      const places = await getPlaces();
      setCar(car);
      setBorrowPlaces(places);
      setReturnPlaces(places);
      const user = await getCurrentUser();
      if (user !== undefined) {
        setCustomerData(user.customer);
        setUser(user);
      }
    }

    fetchCar();
  }, []);

  useEffect(() => {
    countCosts();
  }, [car]);

  const countCosts = (fromArg: Dayjs | null = from, toArg: Dayjs | null = to ) => {
    const days = toArg?.startOf('day')?.diff(fromArg?.startOf('day'), 'day')
    setDays(days ?? 0);
    if (car !== undefined) {
      setCosts((days! * car.pricePerDay!).toFixed(2));
    }
  }

  const handleFromChange = (value: Dayjs | null) => {;
    setFrom(value ?? null);
    countCosts(value, to);
  }
  
  const handleToChange = (value: Dayjs | null) => {
    setTo(value ?? null);
    countCosts(from, value);
  }

  const handleFormChange = (e: React.ChangeEvent<HTMLInputElement>) => {
    const { name, value } = e.target;
    setCustomerData({
      ...customerData,
      [name]: value,
    });
    console.log(customerData);
  };

  const handleFormDatePickerChange = (value: Dayjs) => {
    setCustomerData({
      ...customerData,
      dateOfBirth: value,
    });
  };

  const handleBorrowPlaceChange = (e: SelectChangeEvent) => {
    setSelectedBorrowPlace(e.target.value);
    setRequest({
      ...request,
      borrowPlaceId: Number(e.target.value),
    });
  };

  const handleReturnPlaceChange = (e: SelectChangeEvent) => {
    setSelectedReturnPlace(e.target.value);
    setRequest({
      ...request,
      returnPlaceId: Number(e.target.value),
    });
  };

  const handleRentSubmit = async () => {
    if (from !== null && to != null) {
      try {
        await createRental({
          ...request,
          totalPrice: Number(costs),
          from: from,
          to: to,
          customer: customerData,
          customerId: user ? user.customer.id : undefined,
        });
        navigate("/");
      } catch (error) {
        if (!(error instanceof AxiosError)){
            throw error;
        }
  
        switch (error.response?.status) {
          case 409:
            setError("Car already rented.");
            break;
          case 400: 
            setError("Not all data provided. Please check your fields.");
            break;
          default:
            setError("Server error");
            break;
        }
        setExceptionThrowned(true);
      }
    }
  };

  return { 
    from,
    to, 
    handleFromChange, 
    handleToChange, 
    costs, 
    car, 
    days, 
    customerData, 
    handleReturnPlaceChange, 
    handleBorrowPlaceChange, 
    handleFormChange, 
    handleFormDatePickerChange,
    borrowPlaces,
    returnPlaces,
    handleRentSubmit,
    selectedBorrowPlace,
    selectedReturnPlace,
    error,
    exceptionThrowned,
  };
}