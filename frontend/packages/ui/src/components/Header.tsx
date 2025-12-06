import React from 'react';

export const Header: React.FC = () => (
  <header className="am-header">
    <div className="am-logo">MyAmigurumi</div>
    <button className="am-chip">Categories</button>
    <input className="am-search" placeholder="Search for anything" />
    <div className="am-actions">
      <button aria-label="Login">Login</button>
      <button aria-label="Favorites">❤</button>
      <button aria-label="Cart">🧺</button>
    </div>
  </header>
);
