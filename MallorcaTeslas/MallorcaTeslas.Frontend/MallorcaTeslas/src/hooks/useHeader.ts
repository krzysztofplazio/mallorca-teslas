import { useEffect, useState } from "react";
import { User } from "../types/user";
import { getCurrentUser } from "../api/axios";
import { Cookies } from "react-cookie";
import { useNavigate } from "react-router-dom";

export default function useHeader() {
  const [ user, setUser ] = useState<User>();
  const cookies = new Cookies();
  const navigator = useNavigate();

  useEffect(() => {
    const fetchUser = async () => {
      console.log(cookies.get('.AspNetCore.Cookies'));
      // if (cookies.get('.AspNetCore.Cookies') !== undefined) {
        console.log("user getted");
        setUser(await getCurrentUser());
      // }
    }

    fetchUser();
  }, [])

  const handleOnLogin = async () => {
    navigator('/login');
  }

  return { user, handleOnLogin }
}