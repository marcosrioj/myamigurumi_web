import React from 'react';

type Editorial = { title: string; category: string; href: string };

export const EditorialList: React.FC<{ items: Editorial[] }> = ({ items }) => (
  <section className="am-editorial">
    <h3>Community stories & tips</h3>
    <ul>
      {items.map((item) => (
        <li key={item.title}>
          <a href={item.href}>
            <span className="am-pill">{item.category}</span>
            {item.title}
          </a>
        </li>
      ))}
    </ul>
  </section>
);
