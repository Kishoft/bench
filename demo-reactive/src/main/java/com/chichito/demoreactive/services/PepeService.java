package com.chichito.demoreactive.services;

import org.springframework.stereotype.Service;

import com.chichito.demoreactive.models.Pepe;

import reactor.core.publisher.Mono;

@Service
public class PepeService {
    private final PepeRepository pepeRepository;

    public PepeService(PepeRepository pepeRepository) {
        this.pepeRepository = pepeRepository;
    }

    @SuppressWarnings("null")
    public Mono<Pepe> crear(Pepe pepe) {
        return this.pepeRepository.save(pepe);
    }
}
