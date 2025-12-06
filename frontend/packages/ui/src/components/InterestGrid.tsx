import React from 'react';

type Interest = { title: string; image: string; blurb: string };

export const InterestGrid: React.FC<{ interests: Interest[] }> = ({ interests }) => (
  <section className="am-interest-grid">
    {interests.map((interest) => (
      <article key={interest.title} className="am-interest">
        <img src={interest.image} alt={interest.title} />
        <div>
          <h4>{interest.title}</h4>
          <p>{interest.blurb}</p>
        </div>
      </article>
    ))}
  </section>
);
