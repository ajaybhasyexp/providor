import React from 'react';
import Typography from '@material-ui/core/Typography';
import { styled } from '@material-ui/core/styles';
import Box from '@material-ui/core/Box';
import Card from '@material-ui/core/Card';
import Grid from '@material-ui/core/Grid'

class Meter extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            meters: props.meters
        }
    }

    render() {
        const Item = styled(Card)(({ theme }) => ({
            ...theme.typography.body2,
            padding: theme.spacing(1),
            textAlign: 'left',
            color: theme.palette.text.secondary,
        }));
        const { meters } = this.state;
        if (meters.length > 0) {
            return (<Box sx={{ flexGrow: 1 }}>
                {meters.map((meter, index) => (
                    <Grid container spacing={meters.length}>
                        <Grid item xs={12}>
                            <Item>
                                <Typography>Meter : <b>{index + 1}</b></Typography>
                                <Grid container spacing={3}>
                                    <Grid item xs={12}>
                                        Meter Type: {meter.MeterType}
                                    </Grid>
                                    <Grid item xs={12}>
                                        No: Of Registers: {meter.NumberOfRegisters}
                                    </Grid>
                                    <Grid item xs={12}>
                                        Operating Mode: {meter.OperatingMode}
                                    </Grid>
                                </Grid>
                            </Item>
                        </Grid>
                    </Grid>
                ))
                }
            </Box>
            );
        }
        else {
            <div>No Meters under this meter point</div>
        }
    }
}

export default Meter;