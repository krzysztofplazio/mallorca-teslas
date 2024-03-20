import Card from "@mui/material/Card";
import React from "react";
import './ErrorCard.scss'
import ErrorOutlineIcon from '@mui/icons-material/ErrorOutline';
import CardContent from "@mui/material/CardContent";
import Typography from "@mui/material/Typography";

export default function ErrorCard({error, isEnabled}: {error: string, isEnabled: boolean}) {
    return (
        <React.Fragment>
            <Card className='error-card' sx={{
                display: isEnabled ? 'block' : 'none',
                backgroundColor: '#ffb7b7',
                color: '#bb2124', 
                borderRadius: '5px',
                border: '1px solid rgb(141, 27, 27)',
                margin: '4% 0',
            }}>
                <CardContent>
                    <ErrorOutlineIcon />
                    <Typography variant="body1">
                        {error}
                    </Typography>
                </CardContent>
            </Card>   
        </React.Fragment>
    )
}