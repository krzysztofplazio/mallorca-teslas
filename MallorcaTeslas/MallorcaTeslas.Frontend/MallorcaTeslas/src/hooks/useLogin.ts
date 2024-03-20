import { AxiosError } from "axios";
import { useState } from "react";
import { useNavigate } from "react-router-dom";
import { loginUser } from "../api/axios";

export default function useLogin() {
  const navigate = useNavigate();
  const [username, setUsername] = useState("");
  const [password, setPassword] = useState("");
  const [exceptionThrowned, setExceptionThrowned] = useState(false);
  // const [user, setUser] = useState<IUser>();
  const [loadingEnabled, setLoadingEnabled] = useState(false);
  const [error, setError] = useState("");

  const handleMouseDownPassword = (event: React.MouseEvent<HTMLButtonElement>) => {
    event.preventDefault();
  };

  const handleLoginInputChange = (event: React.ChangeEvent<HTMLInputElement>) => {
    setUsername(event.target.value);
  };

  const handlePasswordInputChange = (event: React.ChangeEvent<HTMLInputElement>) => {
    setPassword(event.target.value);
  };

  const handleSubmit = async (event: React.SyntheticEvent<HTMLFormElement>) => {
    event.preventDefault();
    const credentials: LoginCredentials = {
      username: username,
      password: password,
    }
    try {
      if (username == "" || password == "") {
        setError("Fields have to be filled.");
        setExceptionThrowned(true);
        return;
      }

      setLoadingEnabled(true);
      await loginUser(credentials);
      setLoadingEnabled(false);

      navigate("/");
    } catch (error) {
      if (!(error instanceof AxiosError)){
          throw error;
      }

      switch (error.response?.status) {
          case 404:
            setError(`User ${credentials.username} have no access to application.`);
            break;
          case 400:
            setError("Bad login or password");
            break;
          default: 
            setError("Server error");
            break;
      }
      setExceptionThrowned(true);
    }
    finally {
      setLoadingEnabled(false);
    }
  };

  return { handleSubmit, username, handleMouseDownPassword, handleLoginInputChange, handlePasswordInputChange, password, loadingEnabled, error, exceptionThrowned }
}