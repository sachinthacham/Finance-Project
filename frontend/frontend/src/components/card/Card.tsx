import { CompanySearch } from '../../company';
import './Card.css'
import AddPortfolio from '../portfolio/Portfolio';
import { SyntheticEvent } from 'react';

interface Props{
id:string;
searchResult:CompanySearch;
onPortfolioCreate: (e:SyntheticEvent) => void;
}

const Card:React.FC<Props> = ({id, searchResult,onPortfolioCreate}:Props):JSX.Element => {
  return (
    <div key={id} id={id} className='card'>
        <img src = "https://images.unsplash.com/photo-1725203574073-79922f64110a?w=900&auto=format&fit=crop&q=60&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxmZWF0dXJlZC1waG90b3MtZmVlZHwyfHx8ZW58MHx8fHx8"
        alt='unsplash image'
        />
        <div className='details'>
            <h2>{searchResult.name}({searchResult.symbol})</h2>
            <p>{searchResult.currency}</p>
        </div>
        <p className='info'>
          {searchResult.exchangeShortName} - {searchResult.stockExchange}
        </p>
      <AddPortfolio onPortfolioCreate={onPortfolioCreate} symbol={searchResult.symbol}/>
    </div>
  )
}

export default Card