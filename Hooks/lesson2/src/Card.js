const Card = ({ children }) => {
  return (
    <div className="w-3/4 bg-white shadow-md rounded px-8 pt-6 pb-8 mb-4">
      {children}
    </div>
  );
};

export default Card;
