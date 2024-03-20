import { Box, Button, FormControl, Grid, InputLabel, MenuItem, Select, TextField, Typography } from "@mui/material";
import './RentCar.scss'
import { DatePicker } from "@mui/x-date-pickers";
import useRentCar from "../../hooks/useRentCar";
import dayjs from "dayjs";
import TeslaInfo from "../../components/cars/TeslaInfo";
import ErrorCard from "../../components/informational/ErrorCard";

export default function RentCar() {
  const {
    from,
    to,
    handleFromChange,
    handleToChange,
    costs,
    car,
    days,
    customerData,
    handleFormChange,
    handleFormDatePickerChange,
    handleBorrowPlaceChange,
    handleReturnPlaceChange,
    borrowPlaces,
    returnPlaces,
    handleRentSubmit, 
    selectedBorrowPlace,
    selectedReturnPlace,
    error,
    exceptionThrowned,
  } = useRentCar();
  return(
    <>
      {car !== undefined
        ?
      <Box className='rent-car-main-box'>
          <TeslaInfo car={car} />
          <div style={{
            display: 'flex',
          }}>
            <Box sx={{
              width: '50%',
              display: 'flex',
              flexDirection: 'column',
              border: '1px solid #999',
              padding: 2,
              borderRadius: '5px',
              margin: '20px 0',
            }}>
              <Typography variant="body1" sx={{
                margin: '10px 0',
                fontSize: 20,
                fontWeight: 'bold',
              }}>
                Select your rent date:
              </Typography>
                <DatePicker 
                  label="Rental from" 
                  value={from}
                  onChange={handleFromChange}
                  disablePast
                  sx={{
                    margin: '15px 0'
                  }}
                />
                <DatePicker 
                  label="Rental to"
                  value={to}
                  onChange={handleToChange}
                  disablePast
                  minDate={from?.add(1, 'days') ?? undefined}
                  maxDate={from?.add(car.rentDays, 'days')}
                />
              <FormControl sx={{
                    margin: '15px 0'
                  }}>
                <InputLabel id="borrow-place-label">Borrow place</InputLabel>
                <Select
                  labelId="borrow-place-label"
                  label="Borrow place"
                  value={selectedBorrowPlace}
                  onChange={handleBorrowPlaceChange}
                  >
                  {borrowPlaces.map((place: Place) => (
                    <MenuItem key={place.id} value={place.id}>{place.location}</MenuItem>
                  ))}
                </Select>
              </FormControl>
              <FormControl>
                <InputLabel id="Return-place-label">Return place</InputLabel>
                <Select
                  labelId="return-place-label"
                  label="Return place"
                  value={selectedReturnPlace}
                  onChange={handleReturnPlaceChange}
                >
                  {returnPlaces.map((place: Place) => (
                    <MenuItem key={place.id} value={place.id}>{place.location}</MenuItem>
                  ))}
                </Select>
              </FormControl>
              { costs !== undefined ?
              <p style={{
                textAlign: 'right',
              }}>
                <span>Total costs:</span> 
                <span style={{
                  fontWeight: 500,
                }}> {costs} {car.currency} / {days} day(s) </span>
              </p>
                : <p></p>}
            </Box>
          <Box className='customer-form'>
            <Typography variant="body1" sx={{
                fontSize: 20,
                fontWeight: 'bold',
              }}>
              Fill below fields
            </Typography>
            <Grid container sx={{
              display: 'flex',
              justifyContent: 'space-between',
              alignItems: 'center',
              height: '100%',
            }}>          
              <Grid item>
                <TextField value={customerData.fullName} name="fullName" onChange={handleFormChange} label="Full name" type="text" variant="outlined" />
              </Grid>
              <Grid item>
                <DatePicker value={dayjs(customerData.dateOfBirth)} onChange={(value) => handleFormDatePickerChange(value!)} label="Birth date" maxDate={dayjs().subtract(18, 'year')} />
              </Grid>
              <Grid item>
              <TextField value={customerData.address} name="address" onChange={handleFormChange} label="Address" type="text" variant="outlined" />
              </Grid>
              <Grid item>
              <TextField value={customerData.country} name="country" onChange={handleFormChange} label="Country" type="text" variant="outlined" />
              </Grid>
              <Grid item>
              <TextField value={customerData.phone} name="phone" onChange={handleFormChange} label="Phone" variant="outlined" />
              </Grid>
              <Grid item>
              <TextField value={customerData.email} name="email" onChange={handleFormChange} label="Email" type="email" variant="outlined" />
              </Grid>
            </Grid>
          </Box>
          </div> 
          <div>
            <Button onClick={handleRentSubmit} variant="contained" sx={{ width: '30%' }}>
              Rent a car!
            </Button>
            <ErrorCard error={error} isEnabled={exceptionThrowned} />
          </div>
      </Box> : <>Loading</> }
    </>
  );
}