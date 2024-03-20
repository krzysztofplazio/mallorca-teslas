import { Typography } from '@mui/material';
import { useCars } from '../../hooks/useCars';
import './Cars.scss';
import EmptySet from '../../components/informational/EmptySet';
import CarDetails from '../../components/cars/CarDetails';

export default function Cars() {
  const {
    cars,
    from,
    to,
  } = useCars();
  return(
    <div className='car-container'>
      <Typography variant='h3' sx={{
        margin: '30px 0'
      }}>
        Lists of available Teslas from {from.format("DD.MM.YYYY")} to {to.format("DD.MM.YYYY")}.
      </Typography>
      {/* <div className='car-list'> */}
        { cars !== undefined 
          ? cars.totalCount !== 0 
            ? cars.items.map((car) => (
                <CarDetails car={car} />
                )) : <EmptySet />
                : <div>Loading</div> }
      {/* </div> */}
    </div>
  );
}