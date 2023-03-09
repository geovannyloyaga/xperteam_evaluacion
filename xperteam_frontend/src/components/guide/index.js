/* eslint-disable react-hooks/exhaustive-deps */
import axios from "axios";
import moment from "moment/moment";
import { useEffect, useRef, useState } from "react";
import { Button, Spinner, Table } from "react-bootstrap";
import { toast } from "react-toastify";

const Guide = () => {

    const [guidesData, setGuidesData] = useState({ loading: false, data: [] });
    const mounted = useRef(false);
    const currency = 'USD';

    function getGuides() {
        setGuidesData({ ...guidesData, loading: true });
        axios.get('https://localhost:7278/api/Guide/List')
            .then(function (response) {
                let responseApi = response.data;
                if (responseApi.status) {
                    setGuidesData({ loading: false, data: responseApi.data });
                    return;
                }
                setGuidesData({ loading: false, data: [] });
                toast("No se encontró guías registradas");
            })
            .catch(function (error) {
                // handle error
                setGuidesData({ loading: false, data: [] });
                toast("Hubo inconveniente en el sistema");
            })
            .finally(function () {
                // always executed
            });
    }

    useEffect(() => {
        if (!mounted.current) {
            getGuides();
            mounted.current = true;
        }

        return () => { }
    }, []);


    return <>
        <div className="row mb-2">
            <div className="col-9">
                <h5>Lista de guías</h5>
            </div>
            <div className="col-3" style={{ textAlign: 'right' }}>
                <Button onClick={() => { getGuides() }} variant="outline-secondary" style={{ marginRight: 8 }}>Actualizar</Button>
                <Button variant="outline-primary">Crear nueva guía</Button>
            </div>
        </div>
        <div>
            {
                guidesData.loading ?
                    <div style={{ display: 'flex', justifyContent: 'center', height: 'calc(100vh - 200px)' }}>
                        <Spinner animation="grow" style={{ alignSelf: 'center' }} />
                    </div> :
                    <Table responsive striped bordered hover>
                        <thead>
                            <tr>
                                <th>ID GUÍA</th>
                                <th>NÚMERO DE GUÍA</th>
                                <th>FECHA ENVÍO</th>
                                <th>PAÍS ORIGEN</th>
                                <th>NOMBRE REMIT.</th>
                                <th>DIRECCIÓN REMIT.</th>
                                <th>TELÉFONO REMIT.</th>
                                <th>EMAIL REMIT.</th>
                                <th>PAÍS DEST.</th>
                                <th>NOMBRE DEST.</th>
                                <th>DIRECCIÓN DEST.</th>
                                <th>TELÉFONO DEST.</th>
                                <th>EMAIL DEST.</th>
                                <th>TOTAL</th>
                            </tr>
                        </thead>
                        <tbody>
                            {
                                guidesData.data?.length > 0 && guidesData.data.map(guide => (<tr>
                                    <td>{guide?.idGuide}</td>
                                    <td>{guide?.numberGuide}</td>
                                    <td>{moment(guide?.shippingDate).format('YYYY-MM-DD HH:mm:ss')}</td>
                                    <td>{guide?.countryOrigin}</td>
                                    <td>{guide?.senderName}</td>
                                    <td>{guide?.senderAddress}</td>
                                    <td>{guide?.senderPhone}</td>
                                    <td>{guide?.senderEmail}</td>
                                    <td>{guide?.destinationCountry}</td>
                                    <td>{guide?.recipientName}</td>
                                    <td>{guide?.recipientAddress}</td>
                                    <td>{guide?.recipientPhone}</td>
                                    <td>{guide?.recipientEmail}</td>
                                    <td>{guide?.total.toLocaleString('en-US', {
                                        style: 'currency',
                                        currency: currency,
                                    })}</td>
                                </tr>))
                            }
                        </tbody>
                    </Table>
            }
        </div>
    </>;
};

export default Guide;