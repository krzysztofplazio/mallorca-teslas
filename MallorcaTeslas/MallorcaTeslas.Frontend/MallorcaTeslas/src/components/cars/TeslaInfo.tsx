import { Box, Divider, Typography } from "@mui/material";
import "./TeslaInfo.scss"

export default function TeslaInfo({ car }: { car: Car }) {
    return (
        <Box className="car-info">
            <Typography variant="body1" sx={{
              fontSize: 30,
              fontWeight: 'bold'
            }}>
              {car.mark} {car.model}
            </Typography>
            <Divider />
            <Typography variant="body2" className="car-property" sx={{
              fontSize: 20,
              textTransform: 'uppercase',
              fontWeight: 'bold',
            }}>
              Info about car:
            </Typography>
            <div>
            <Typography variant="body2" className="car-property">
              <span className="bolded-column">Power:</span>
              <span>{car.power} HP</span>
            </Typography>
            <Typography variant="body2" className="car-property">
              <span className="bolded-column">Charging minutes:</span>
              <span>{car.chargingMinutes}</span>
            </Typography>
            <Typography variant="body2" className="car-property">
              <span className="bolded-column">Production Year:</span>
              <span>{car.productionYear}</span>
            </Typography>
            <Typography variant="body2" className="car-property">
              <span className="bolded-column">Price: </span>
              <span>{car.pricePerDay} {car.currency} / day</span>
            </Typography>
            <Typography variant="body2" className="car-property">
              <span className="bolded-column">Max range limit:</span>
              <span>{car.rangeLimit} km</span>
            </Typography>
            <Typography variant="body2" className="car-property">
              <span className="bolded-column">Max rent days:</span>
              <span>{car.rentDays}</span>
            </Typography>
            </div>
          </Box>
    )
}