import './App.css'
import { LocalizationProvider } from '@mui/x-date-pickers'
import { AdapterDayjs } from '@mui/x-date-pickers/AdapterDayjs'
import { ThemeProvider } from 'styled-components'
import { createTheme } from '@mui/material'
import { BrowserRouter, Route, Routes } from 'react-router-dom'
import MainLayout from './views/MainLayout/MainLayout'
import 'dayjs/locale/pl';
import { CookiesProvider } from 'react-cookie'
import Login from './views/login/Login'


function App() {
  const theme = createTheme();
  return (
    <>
      <ThemeProvider theme={theme}>
        <CookiesProvider>
          <LocalizationProvider dateAdapter={AdapterDayjs} adapterLocale='pl'>
            <BrowserRouter>
              <Routes>
                <Route path='/login' element={<Login />} />
                <Route path='*' element={<MainLayout />} />
              </Routes>
            </BrowserRouter>
          </LocalizationProvider>
        </CookiesProvider>
      </ThemeProvider>
    </>
  )
}

export default App
