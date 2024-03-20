import { Route, Routes } from 'react-router-dom';
import Header from '../../components/header/Header';
import './MainLayout.scss'
import RentalSearch from '../RentalSearch/RentalSearch';
import Cars from '../Cars/Cars';
import RentCar from '../RentCar/RentCar';
import RentalsTable from '../Rentals/RentalsTable';
export default function MainLayout() {
  return(
    <>
      <div className='base'>
        <Header />
        <div className='container-flex'>
          <div className='container'>
            <Routes>
                <Route path='/' element={<RentalSearch />}/>
                <Route path='/cars' element={<Cars />}/>
                <Route path='/cars/:carId/rent-car' element={<RentCar />}/>
                <Route path='/my-rentals' element={<RentalsTable />}/>
                <Route path='*' element={<span>404: The page you are looking for isn't here
You either tried some shady route or you came here by mistake. Whichever it is, try using the navigation</span>} />
            </Routes>
          </div>
        </div>
      </div>
    </>
  );
}