import Card from '../card/Card';
import { CompanySearch } from '../../company';
import { SyntheticEvent } from 'react';

interface Props {
  searchResult : CompanySearch[];
  onPortfolioCreate:(e:SyntheticEvent) => void;
}

const CardList:React.FC<Props> = ({searchResult,onPortfolioCreate}: Props):JSX.Element => {
  return (
    <div>
 
      {
        searchResult.length > 0?(
          searchResult.map((result, i) => (
            <Card key={i} id ={result.symbol} searchResult={result} onPortfolioCreate={onPortfolioCreate}/>
          ))
        ):(
          <h1> No results</h1>
        )
      }

      
        
    </div>
  )
}

export default CardList 