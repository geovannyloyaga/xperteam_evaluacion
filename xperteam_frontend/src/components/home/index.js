import InvoiceBackground from '../../assets/img/invoice_background.jpg';

const Home = () => {
    return <>
        <div className="text-center">
            <h3>Bienvenido !</h3>
        </div>
        <div className='text-center'>
            <img src={InvoiceBackground} alt="img" width={850}/>
        </div>
    </>;
};

export default Home