import Accordion from '@material-ui/core/Accordion';
import React from 'react';
import ExpandMoreIcon from '@material-ui/icons/ExpandMore';
import AccordionDetails from '@material-ui/core/AccordionDetails';
import AccordionSummary from '@material-ui/core/AccordionSummary';
import Typography from '@material-ui/core/Typography';
import Meter from './Meter';
import { styled } from '@material-ui/core/styles';
import Box from '@material-ui/core/Box';
import Paper from '@material-ui/core/Paper';
import Grid from '@material-ui/core/Grid';


class MeterPoint extends React.Component {

    constructor(props) {
        super(props);
        this.state = {
            error: null,
            isLoaded: false,
            meterPoints: []
        }
    }

    componentDidMount() {
        fetch("https://tech-test-api.azurewebsites.net/meterpoints")
            .then(res => res.json())
            .then((result) => {
                this.setState({
                    isLoaded: true,
                    meterPoints: result
                });
            },
                (error) => {
                    this.setState({
                        error,
                        isLoaded: true,
                        meterPoints: []
                    })
                })
    }

    render() {
        const Item = styled(Paper)(({ theme }) => ({
            ...theme.typography.body2,
            padding: theme.spacing(1),
            textAlign: 'center',
            color: theme.palette.text.secondary,
          }));
        // const handleChange = (panel) => (event, isExpanded) => {
        //     setExpanded(isExpanded ? panel : false);
        // };
        // const [expanded, setExpanded] = React.useState(false);
        const { error, isLoaded, meterPoints } = this.state;
        if (error) {
            return <div>Error: Error while calling API</div>
        }
        else if (!isLoaded) {
            return <div>Loading...</div>
        }
        else {
            // <Accordion expanded={expanded === 'panel1'} onChange={handleChange('panel1')}></Accordion>
            return (<Box sx={{ flexGrow: 1 }}>
                {meterPoints.map(meterPoint => (
                    <Grid container spacing={meterPoints.length}>
                        <Grid item xs={12}>
                            <Item>
                                <Accordion >
                                    <AccordionSummary expandIcon={< ExpandMoreIcon />}
                                        aria-controls="panel1a-content"
                                        id="panel1a-header">
                                        <Typography>Meter Point: {meterPoint.Mpan}</Typography>
                                    </AccordionSummary>
                                    <AccordionDetails>                                        
                                        <Meter meters={meterPoint.Meters} />
                                    </AccordionDetails>
                                </Accordion >
                            </Item>
                        </Grid>
                    </Grid>
                ))
                }
            </Box>
            );
        }

    }
}

export default MeterPoint;