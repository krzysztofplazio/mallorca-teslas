import dayjs, { Dayjs } from "dayjs";
import { useState } from "react";
import { useNavigate } from "react-router-dom";

export default function useRentalSearch() {
  const [from, setFrom] = useState<Dayjs | null>(dayjs());
  const [to, setTo] = useState<Dayjs | null>(dayjs().add(7, 'day'));
  const navigate = useNavigate();
  
  const handleFromChange = (value: Dayjs | null) => {
    setFrom(value);
  }

  const handleToChange = (value: Dayjs | null) => {
    setTo(value);
  }

  const handleSearch = () => {
    sessionStorage.setItem('from', from?.format('YYYY-MM-DD')!);
    sessionStorage.setItem('to', to?.format('YYYY-MM-DD')!);
    navigate('/cars');
  }

  return { from, to, handleFromChange, handleToChange, handleSearch };
}


