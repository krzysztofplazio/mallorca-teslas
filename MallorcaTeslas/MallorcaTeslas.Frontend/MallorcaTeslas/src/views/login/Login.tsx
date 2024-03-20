import { Box, Button, CircularProgress, FormControl, IconButton, Input, InputAdornment, InputLabel } from "@mui/material";
import './Login.scss';
import React from "react";
import { AccountCircle } from "@mui/icons-material";
import KeyRoundedIcon from '@mui/icons-material/KeyRounded';
import ErrorCard from "../../components/informational/ErrorCard";
import useLogin from "../../hooks/useLogin";

export default function Login() {

  const { handleSubmit, username, handleLoginInputChange, handleMouseDownPassword, handlePasswordInputChange, password, error, exceptionThrowned, loadingEnabled } = useLogin();

  return (
    <React.Fragment>
      {/* { localStorage.getItem("token") != null ? <Navigate to="/" /> :  */}
      <div className="container-login">
        <Box className='login-box'>
          <Box className="logo">
                <h3>Mallorca Teslas</h3>
            </Box>
          <form onSubmit={handleSubmit}>
            <FormControl variant="standard" color="success">
              <InputLabel htmlFor="login">
                Login
              </InputLabel>
              <Input
                  id="login"
                  type="text"
                  startAdornment={
                    <InputAdornment position="start">
                      <AccountCircle />
                    </InputAdornment>
                  }
                  value={username}
                  onChange={handleLoginInputChange}
                />
            </FormControl>
            <FormControl variant="standard" color="success">
              <InputLabel htmlFor="password">
                Password
              </InputLabel>
              <Input
                id="outlined-adornment-password"
                type="password"
                startAdornment={
                  <InputAdornment position="start">
                    <KeyRoundedIcon />
                  </InputAdornment>
                }
                endAdornment={
                  <InputAdornment position="end">
                    <IconButton
                      aria-label="toggle password visibility"
                      onMouseDown={handleMouseDownPassword}
                      edge="end"
                    >
                    </IconButton>
                  </InputAdornment>
                }
                onChange={handlePasswordInputChange}
                value={password}
              />
            </FormControl>
            <ErrorCard error={error} isEnabled={exceptionThrowned} />
            {!loadingEnabled ? 
            <Button className="login-button"
                    variant="contained" 
                    type="submit">Log in</Button> :
            <CircularProgress color="secondary" /> }
          </form>
        </Box>
      </div> 
    </React.Fragment>
  );
};