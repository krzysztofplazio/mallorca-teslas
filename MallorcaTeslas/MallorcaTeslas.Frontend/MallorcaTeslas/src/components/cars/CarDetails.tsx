import { Box, Button, Typography } from "@mui/material";
import './CarDetails.scss';
import useCarDetails from "../../hooks/useCarDetails";

export default function CarDetails({ car } : { car: Car }) {
  const {
    handleRentCar
  } = useCarDetails();
  return(
    <Box className='main-box'>
      <div className="box-container">
        <div>
          <Typography variant="h5" sx={{
            fontWeight: 'bold'
          }}>
            {car.mark}
          </Typography>
          <Typography variant="body1" sx={{ color: '#777' }}>
            {car.model}
          </Typography>
          <Typography variant="body2" sx={{ color: '#003' }}>
            {car.pricePerDay} {car.currency} / day
          </Typography>
          <Button variant='outlined' onClick={() => handleRentCar(car.id)}>
            Rent this car
          </Button>
        </div>
      </div>
  </Box>
  );
}