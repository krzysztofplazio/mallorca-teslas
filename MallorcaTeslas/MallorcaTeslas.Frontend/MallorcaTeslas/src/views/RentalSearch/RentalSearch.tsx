import { Box, Button, Typography } from "@mui/material";
import './RentalSearch.scss'
import { DatePicker } from "@mui/x-date-pickers";
import useRentalSearch from "../../hooks/useRentalSearch";

export default function RentalSearch() {
  const { 
    from,
    to,
    handleFromChange,
    handleToChange,
    handleSearch
   } = useRentalSearch();

  return(
    <div className="search-base">
      <Typography variant="h3">
        Rent Tesla today!
      </Typography>
      <Box className='search-box'>
        <Typography variant="h6">
          Check available cars below.
        </Typography>
        <DatePicker 
          label="Rental from" 
          value={from}
          onChange={handleFromChange}
          disablePast
          maxDate={to ?? undefined}
        />
        <DatePicker 
          label="Rental to"
          value={to}
          onChange={handleToChange}
          disablePast
          minDate={from?.add(1, 'days') ?? undefined}
        />
        <Button variant="contained" onClick={handleSearch}>
          Search
        </Button>
      </Box>
    </div>
  )
}