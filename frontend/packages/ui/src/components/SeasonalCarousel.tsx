import React from 'react';

type SeasonalItem = {
  title: string;
  description: string;
  expiresAt: string;
  image: string;
};

export const SeasonalCarousel: React.FC<{ items: SeasonalItem[] }> = ({ items }) => (
  <section className="am-seasonal">
    {items.map((item) => (
      <article key={item.title} className="am-seasonal-card">
        <img src={item.image} alt={item.title} />
        <div>
          <p className="am-kicker">Seasonal drop</p>
          <h3>{item.title}</h3>
          <p>{item.description}</p>
          <p className="am-countdown">Ends {new Date(item.expiresAt).toLocaleString()}</p>
        </div>
      </article>
    ))}
  </section>
);
