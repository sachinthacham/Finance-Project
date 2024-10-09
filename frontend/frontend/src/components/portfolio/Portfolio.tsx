import { SyntheticEvent } from "react";

interface Props{
    onPortfolioCreate:(e:SyntheticEvent) => void;
    symbol:string;
}

const Portfolio = ({onPortfolioCreate,symbol}: Props) => {
  return (
    <form onSubmit={onPortfolioCreate}>
        <input readOnly={true} hidden={true} value={symbol}></input>
        <button type="submit">submit</button>
    </form>
  )
}

export default Portfolio;