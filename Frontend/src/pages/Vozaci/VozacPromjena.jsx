import VozacService from "../../services/VozacService"
import { Button, Row, Col, Form } from "react-bootstrap";
import { Link, useNavigate, useParams } from "react-router-dom";
import { RouteNames } from "../../constants";
import { useEffect, useState } from "react";


export default function VozaciPromjena(){

    const [vozac,setVozac] = useState({})
    const navigate = useNavigate()
    const routeParams = useParams()

    async function dohvatiVozac(){
        const odgovor = await VozacService.getBySifra(routeParams.sifra);
        if(odgovor.greska){
            alert(odgovor.poruka)
            return
        }
        setVozac(odgovor.poruka)
        //debugger; // ovo radi u Chrome inspect (ali i ostali preglednici)
        
    } 

    useEffect(()=>{
        dohvatiVozac();
     },[])

     async function promjena(vozac) {
        //console.log(smjer)
        //console.log(JSON.stringify(smjer))
        const odgovor = await VozacService.promjena(routeParams.sifra,vozac)
        if(odgovor.greska){
            alert(odgovor.poruka)
            return;
        }
        navigate(RouteNames.VOZAC_PREGLED)
    }

    function obradiSubmit(e){ // e je event
        e.preventDefault(); // nemoj odraditi zahtjev na server
        let podaci = new FormData(e.target)
        //console.log(podaci.get('naziv'))
        promjena({
            ime: podaci.get('ime'),
            prezime: podaci.get('prezime'),
            oib: podaci.get('oib'),
             
        })
    }

    return(
        <>
        Promjena vozaca
        <Form onSubmit={obradiSubmit}>

            <Form.Group controlId="ime">
                <Form.Label>Ime</Form.Label>
                <Form.Control type="text" name="ime" required
                defaultValue={vozac.ime} />
            </Form.Group>

            <Form.Group controlId="prezime">
                <Form.Label>Prezime</Form.Label>
                <Form.Control type="text" name="prezime" required
                defaultValue={vozac.prezime} />
            </Form.Group>

            <Form.Group controlId="oib">
                <Form.Label>Oib</Form.Label>
                <Form.Control type="text" name="oib" required
                defaultValue={vozac.oib} />
            </Form.Group>

            


        <Row className="akcije">
            <Col xs={6} sm={12} md={3} lg={6} xl={6} xxl={6}>
            <Link to={RouteNames.VOZAC_PREGLED} 
            className="btn btn-danger siroko">Odustani</Link>
            </Col>
            <Col xs={6} sm={12} md={9} lg={6} xl={6} xxl={6}>
            <Button variant="success"
            type="submit"
            className="siroko">Promjeni vozaca</Button>
            </Col>
        </Row>
        </Form>
        </>
    )
}