import { Box, Button, Typography } from '@mui/material';
import './Header.scss'
import useHeader from '../../hooks/useHeader';
import { NavLink } from 'react-router-dom';

export default function Header() {  
  const { user } = useHeader();
  return(
    <>
      <Box className='header-box'>
        <div className='header-container'>
          <Typography variant='h2' component={NavLink} to="/" sx={{
            textDecoration: 'none',
            color: 'white',
            '&:hover': {
              color: '#eee'
            }
          }}>
            Mallorca Teslas
          </Typography>
          { user === undefined ? 
          <Button sx={{
              color: 'white'
            }}
            component={NavLink}
            to="/login"
          >
            Login
          </Button> :
          <div style={{
            display: 'flex',
            justifyContent: 'flex-end'
          }}>
            <Typography style={{color: 'white', margin: 0, marginRight: '10px'}}>Hello {user.username}!</Typography>
            <Typography 
              component={NavLink} 
              to="/my-rentals"
              sx={{
                textDecoration: 'none',
                color: 'white',
                '&:hover': {
                  color: '#eee'
              }}}>Show my rentals</Typography>
          </div>}
        </div>  
      </Box>
    </>
  );
}