import { useNavigate } from "react-router-dom";

export default function useCarDetails() {
  const navigate = useNavigate();

  const handleRentCar = (carId: number) => {
    navigate(`/cars/${carId}/rent-car`);
  }

  return { handleRentCar };
}